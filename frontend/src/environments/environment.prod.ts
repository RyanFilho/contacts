import { EnvironmentConfiguration } from "../app/models/environment-configuration";

const serverUrl = 'https://contacts-api-fdcce6ggdsbwfxfy.brazilsouth-01.azurewebsites.net/api';

export const environment: EnvironmentConfiguration = {
  env_name: 'prod',
  production: true,
  apiUrl: serverUrl,
  apiEndpoints: {
    userProfile:'user-profiles'
  },
  adConfig: {
    clientId: '67c3e590-5483-44c4-be7c-045e8d75c650',
    tenantId: '08c7ece1-e65a-4cf9-8e27-24d35b054769',
    readScopeUrl: 'api://08fdedab-dd1c-41a5-a199-fff663007ea5/Contacts.Write',
    writeScopeUrl: 'api://08fdedab-dd1c-41a5-a199-fff663007ea5/Contacts.Read',
    scopeUrls:[
      'api://08fdedab-dd1c-41a5-a199-fff663007ea5/Contacts.Write',
      'api://08fdedab-dd1c-41a5-a199-fff663007ea5/Contacts.Read'
    ],
    apiEndpointUrl: 'https://contacts-api-fdcce6ggdsbwfxfy.brazilsouth-01.azurewebsites.net/api'
  },
  cacheTimeInMinutes: 30,
};

