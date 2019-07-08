import { Injectable } from '@angular/core';

declare var fs: any;
declare var electron: any;

@Injectable({
  providedIn: 'root'
})
export class FileService {
  private readonly fs: any;
  private readonly electron: any;
  constructor() {
    this.fs = fs;
    this.electron = electron;
  }

  getConfig() {
    //let item = localStorage.getItem('apiConfig');
    //if (item) {
    //  return JSON.parse(item);
    //}

    if (this.fs != undefined) {
      console.log('fileservice: ', this.fs);
      let configFile = this.fs.readFileSync('config.json');
      let json = JSON.parse(configFile);;
      return json;
    }

    if (this.electron != undefined) {
      console.log('local electron: ', this.electron);
      let path = this.electron.getAppPath();
      console.log(path);

    }
    return { apiUrl: '' };
  }
}
