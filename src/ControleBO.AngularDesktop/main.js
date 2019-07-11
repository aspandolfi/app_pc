const { app, BrowserWindow, dialog } = require('electron');
const { autoUpdater } = require("electron-updater");

let updater;
autoUpdater.autoDownload = false;
let win;
function createWindow() {
  // Create the browser window.
  win = new BrowserWindow({ width: 1024, height: 768, maximizable: false, resizable: false, icon: './src/favicon.ico' });
  // and load the index.html of the app. 
  win.loadFile('./dist/ControleBO-AngularDesktop/index.html');

  win.setMenuBarVisibility(false);
  win.setMenu(null);
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
