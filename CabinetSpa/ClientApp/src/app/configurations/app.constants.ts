import { Injectable } from '@angular/core';

@Injectable()
export class Configuration {
    public server = 'http://localhost:50339';
    public apiUrl = '/api';
    public serverWithApiUrl = this.server + this.apiUrl;
    public patientServer = this.server + this.apiUrl + '/Patient';
}
