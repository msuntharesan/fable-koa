const path = require('path');
const del = require('del');
const fable = require('fable-compiler');

const tasks = {
  test() {
    return del(['Fable.Import.Koa.{dll,fablemap,xml}', '__tests__'])
      .then(_ => fable.compile({ projFile: 'src' }))
      .then(_ => fable.compile({ projFile: 'tests' }));
  },
  prod() {
    return del(['Fable.Import.Koa.{dll,fablemap,xml}'])
      .then(() => fable.compile({ projFile: 'src' }));
  }
}

const [, , task = 'prod'] = process.argv;
tasks[task]()
  .catch(err => {
    console.log('[ERROR] ' + err);
    process.exit(-1);
  });