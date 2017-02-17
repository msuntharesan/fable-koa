const path = require('path');
const del = require('del');
const fable = require('fable-compiler');

del(['Fable.Import.Koa.{dll,fablemap,xml}', '__tests__'])
  .then(_ => fable.compile('src'))
  .then(_ => fable.compile('tests'))
  .then(_ => fable.runCommand('.', 'npm test'))
  .catch(err => {
    console.log('[ERROR] ' + err);
    process.exit(-1);
  });
