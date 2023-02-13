import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'CacheManagement',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44319/',
    redirectUri: baseUrl,
    clientId: 'CacheManagement_App',
    responseType: 'code',
    scope: 'offline_access CacheManagement',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44319',
      rootNamespace: 'JS.Abp.CacheManagement',
    },
    CacheManagement: {
      url: 'https://localhost:44314',
      rootNamespace: 'JS.Abp.CacheManagement',
    },
  },
} as Environment;
