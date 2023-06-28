import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';

declare module 'd3-shape';
declare module 'd3-scale';
declare module 'd3-selection'; 

platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.error(err));
