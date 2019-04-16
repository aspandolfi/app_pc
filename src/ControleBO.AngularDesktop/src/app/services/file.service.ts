import { Injectable } from '@angular/core';

declare var fs: any;

@Injectable({
  providedIn: 'root'
})
export class FileService {
  private readonly fs: any;
  constructor() {
    this.fs = fs;
  }

  getConfig() {
    if (fs !== undefined) {
      var configFile = this.fs.readFileSync('./config.json');
      return JSON.parse(configFile);
    }
    return { apiUrl: "http://localhost:1647/" };
  }
}
