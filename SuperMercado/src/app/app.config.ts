import { ApplicationConfig, provideBrowserGlobalErrorListeners } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideClientHydration, withEventReplay } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, provideHttpClient, withFetch, withInterceptorsFromDi } from '@angular/common/http';

import { routes } from './app.routes';
import { AuthInterceptor } from './services/auth/interceptor/auth.interceptor';

export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    
    provideHttpClient(
      withFetch(),             
      withInterceptorsFromDi() 
    ),

    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },

    provideRouter(routes),
    provideClientHydration(withEventReplay())
  ]
};