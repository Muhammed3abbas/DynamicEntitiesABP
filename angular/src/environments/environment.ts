 import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:44316/',
  redirectUri: baseUrl,
  clientId: 'Integration_App',
  responseType: 'code',
  scope: 'offline_access Integration',
  requireHttps: true,
};

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'Integration',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44316',
      rootNamespace: 'DynamicEntity.Integration',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
} as Environment;
