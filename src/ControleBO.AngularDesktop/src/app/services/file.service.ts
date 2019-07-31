import { Injectable } from '@angular/core';
import { ApiConfiguration } from '../api-configuration';

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
    this.getConfig();
  }

  getConfig() {
    //let item = localStorage.getItem('apiConfig');
    //if (item) {
    //  return JSON.parse(item);
    //}

    if (this.fs != undefined) {
      console.log('fileservice: ', this.fs);

      fs.watchFile('config.json', (curr, prev) => {
        let configFile = this.fs.readFileSync('config.json');
        let json = JSON.parse(configFile);
        ApiConfiguration.ApiUrl = json.apiUrl;
        //alert('mudou');
      });

      let configFile = this.fs.readFileSync('config.json');
      let json = JSON.parse(configFile);
      ApiConfiguration.ApiUrl = json.apiUrl;
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
