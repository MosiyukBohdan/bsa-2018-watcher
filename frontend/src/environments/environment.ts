// This file can be replaced during build by using the `fileReplacements` array.
// `ng build ---prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  server_url: 'http://localhost:29878',
  client_url: 'http://localhost:4200',
  firebase: {
    apiKey: 'AIzaSyAqhOd734vYHsrlQvjeY8RqLirLY0eJiLc',
    authDomain: 'watcher-92194.firebaseapp.com',
    databaseURL: 'https://watcher-92194.firebaseio.com',
    projectId: 'watcher-92194',
    storageBucket: 'watcher-92194.appspot.com',
    messagingSenderId: '900874954959'
  }
};

/*
 * In development mode, to ignore zone related error stack frames such as
 * `zone.run`, `zoneDelegate.invokeTask` for easier debugging, you can
 * import the following file, but please comment it out in production mode
 * because it will have performance impact when throw error
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
