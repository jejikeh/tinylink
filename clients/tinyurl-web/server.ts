import { CommonEngine } from '@angular/ssr';
import express from 'express';
import { fileURLToPath } from 'node:url';
import { dirname, join, resolve } from 'node:path';
import bootstrap from './src/main.server';
import { APP_BASE_HREF } from '@angular/common';
import axios from 'axios';

const host = 'http://localhost:5200';

// The Express app is exported so that it can be used by serverless Functions.
export function app(): express.Express {
  const server = express();
  const serverDistFolder = dirname(fileURLToPath(import.meta.url));
  const browserDistFolder = resolve(serverDistFolder, '../browser');
  const indexHtml = join(serverDistFolder, 'index.server.html');

  const commonEngine = new CommonEngine();

  server.set('view engine', 'html');
  server.set('views', browserDistFolder);

  // The internal backend api requests mapping
  server.get('/api/**', (req, res) => {
    axios
      .get(host + req.path, req.body)
      .then((data) => {
        res.send(data.data);
      })
      .catch((err) => {
        res.send(err);
      });
  });

  server.post('/api/**', (req, res) => {
    axios
      .post(host + req.path, req.body)
      .then((data) => {
        res.send(data.data);
      })
      .catch((err) => {
        res.send(err);
      });
  });

  server.put('/api/**', (req, res) => {
    axios
      .put(host + req.path, req.body)
      .then((data) => {
        res.send(data.data);
      })
      .catch((err) => {
        res.send(err);
      });
  });

  // Serve static files from /browser
  server.get(
    '*.*',
    express.static(browserDistFolder, {
      maxAge: '1y',
    })
  );

  // All regular routes use the Angular engine
  server.get('*', (req, res, next) => {
    const { protocol, originalUrl, baseUrl, headers } = req;

    commonEngine
      .render({
        bootstrap,
        documentFilePath: indexHtml,
        url: `${protocol}://${headers.host}${originalUrl}`,
        publicPath: browserDistFolder,
        providers: [{ provide: APP_BASE_HREF, useValue: baseUrl }],
      })
      .then((html) => res.send(html))
      .catch((err) => next(err));
  });

  return server;
}

function run(): void {
  const port = process.env['PORT'] || 4000;

  // Start up the Node server
  const server = app();

  server.listen(port, () => {
    console.log(`Tinyurl web client started on http://localhost:${port}`);
  });
}

run();
