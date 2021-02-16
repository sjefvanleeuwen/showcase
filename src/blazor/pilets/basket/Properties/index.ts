//TODO: read doc if there's a better way to reference the exports
import { PiletApi } from 'consumer-portal/app/index.5224cfa2126d9af6174c';

export function setup(app: PiletApi) {
  app.showNotification('Hello from blazor index.js!');
  app.defineBlazorReferences(require('./reference.codegen'));
  app.registerPage('/sample', app.fromBlazor('sample-page'));
}
