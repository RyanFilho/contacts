// This file can be replaced during build by using the `fileReplacements` array.
// `ng build` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

import { EnvironmentConfiguration } from "../app/models/environment-configuration";


const serverUrl='https://localhost:44351/api';


// The list of file replacements can be found in `angular.json`.
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
    apiEndpointUrl: 'https://localhost:44351/api'
  },
  cacheTimeInMinutes: 30,
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.
