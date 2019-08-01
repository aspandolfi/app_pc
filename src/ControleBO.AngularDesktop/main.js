const { app, BrowserWindow, dialog, Menu, MenuItem } = require('electron');
const { autoUpdater } = require("electron-updater");
const prompt = require('electron-prompt');
const fs = require('fs');

let updater;
autoUpdater.autoDownload = false;
let win;

configureMenu();

function configureMenu() {
  var menu = new Menu();
  var menuItems = [
    new MenuItem({ label: 'Arquivo', submenu: [{ label: 'Configurar API', click: onConfigurarApi }] }),
    new MenuItem({ label: 'Ajuda', submenu: [{ label: 'Sobre', click: onSobre }] })
  ];
  for (var menuItem of menuItems) {
    menu.append(menuItem);
  }

  Menu.setApplicationMenu(menu);
}

function watchConfigFile() {
  fs.watchFile('config.json', (curr, prev) => {
    console.log('mudou');
  });
}

function onConfigurarApi() {
  let fileExists = fs.existsSync('config.json');
  let currentUrl = '';
  if (fileExists) {
    let file = fs.readFileSync('config.json');
    currentUrl = JSON.parse(file).apiUrl;
  }

  prompt({
    title: 'Configurar a API do sistema',
    label: 'URL:',
    value: currentUrl,
    resizable: false,
    height: 150,
    customStylesheet: '',
    inputAttrs: {
      type: 'url',
      placeholder: 'http://example.org'
    }
  })
    .then((r) => {
      if (r === null) {
        console.log('user cancelled');
      } else {

        currentUrl = r;
        var json = { apiUrl: currentUrl };
        fs.writeFileSync('config.json', JSON.stringify(json));

        console.log('result', r);
      }
    })
    .catch(console.error);
}

function onSobre() {
  dialog.showMessageBox({
    type: 'info',
    title: 'Sobre o Sistema',
    message: `
              O sistema foi desenvolvido em parceria com a Polícia Civil - ES
              Autor: André Serafim Pandolfi
              E-mail: aspandolfi@gmail.com
              Versão: ${app.getVersion()}`
  });
}

function createWindow() {
  // Create the browser window.
  win = new BrowserWindow({ width: 1024, height: 768, maximizable: false, resizable: false, autoHideMenuBar: true });
  // and load the index.html of the app. 
  win.loadFile('./dist/ControleBO-AngularDesktop/index.html');

  //win.setMenuBarVisibility(false);
  //win.setMenu(null);
  //win.setMenu(menu);
  // Open the DevTools.
  //win.webContents.openDevTools();
  // Emitted when the window is closed.
  win.on('closed', () => {
    win = null
  });
};

autoUpdater.on('error', (error) => {
  dialog.showErrorBox('Erro: ', error == null ? "Desconhecido" : (error.stack || error).toString())
});

autoUpdater.on('download-progress', (progress, bytesPerSecond, percent, total, transferred) => {
  var progressBar = dialog.showMessageBox({
    type: 'info',
    title: 'Atualização em andamento',
    message: `Progresso ${percent} %`
  }, (message) => {
      
  });
});

autoUpdater.on('update-available', () => {
  dialog.showMessageBox({
    type: 'info',
    title: 'Atualizações encontradas',
    message: 'Foram encontradas novas atualizações, você deseja atualizar agora?',
    buttons: ['Sim', 'Não']
  }, (buttonIndex) => {
    if (buttonIndex === 0) {
      autoUpdater.downloadUpdate()
    }
    else {
      updater.enabled = true
      updater = null
    }
  })
});

autoUpdater.on('update-downloaded', () => {
  dialog.showMessageBox({
    title: 'Instalando atualizações',
    message: 'Atualizações baixadas, a aplicação irá fechar para atualizar...'
  }, () => {
    setImmediate(() => autoUpdater.quitAndInstall())
  })
});

// This method will be called when Electron has finished   
// initialization and is ready to create browser windows.   
// Some APIs can only be used after this event occurs.   
app.on('ready', createWindow);

app.on('ready', function () {
  autoUpdater.checkForUpdates();
});

// Quit when all windows are closed.
app.on('window-all-closed', () => {

  // On macOS it is common for applications and their menu bar     
  // to stay active until the user quits explicitly with Cmd + Q     
  if (process.platform !== 'darwin') { app.quit() }
});
app.on('activate', () => {
  // On macOS it's common to re-create a window in the app when the     
  // dock icon is clicked and there are no other windows open.     
  if (win === null) { createWindow() }
});      
