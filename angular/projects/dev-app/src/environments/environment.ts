import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'CacheManagement',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44334/',
    redirectUri: baseUrl,
    clientId: 'CacheManagement_App',
    responseType: 'code',
    scope: 'offline_access CacheManagement',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44334',
      rootNamespace: 'JS.Abp.CacheManagement',
    },
    CacheManagement: {
      url: 'https://localhost:44382',
      rootNamespace: 'JS.Abp.CacheManagement',
    },
  },
} as Environment;
