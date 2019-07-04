const { app, BrowserWindow, globalShortcut } = require('electron');
const { readFileSync } = require('fs');
const { path } = require('path');

let win;
function createWindow() {
  // Create the browser window.
  win = new BrowserWindow({ width: 1024, height: 768, maximizable: false, resizable: false, icon: './src/favicon.ico' });
  // and load the index.html of the app. 
  win.loadFile('./dist/ControleBO-AngularDesktop/index.html');

  win.setMenuBarVisibility(false);
  win.setMenu(null);
  // Open the DevTools.
  win.webContents.openDevTools();
  // Emitted when the window is closed.
  win.on('closed', () => {
    win = null
  });
};
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
