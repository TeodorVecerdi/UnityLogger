const path = require('path');
const cwd = process.cwd();
const source = path.join(cwd, 'bin/Release/netstandard2.1');
const destination = path.join(cwd, '../UnityLogger/Assets/UnityLogger/Runtime');

const fs = require('fs');
fs.copyFileSync(path.join(source, 'UnityLogger.dll'), path.join(destination, 'UnityLogger.dll'));