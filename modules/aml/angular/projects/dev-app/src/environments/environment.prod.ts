import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'AmlManagement',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44390',
    redirectUri: baseUrl,
    clientId: 'AmlManagement_App',
    responseType: 'code',
    scope: 'offline_access AmlManagement',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44390',
      rootNamespace: 'AmlManagement',
    },
    AmlManagement: {
      url: 'https://localhost:44336',
      rootNamespace: 'AmlManagement',
    },
  },
} as Environment;
