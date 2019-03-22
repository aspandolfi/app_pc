import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';
import { BaseService } from '../../services/base.service';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    providers: [BaseService]
})
export class HomeComponent implements OnInit {

    constructor(private baseService: BaseService) { }

    ngOnInit(): void {

    }

    getAll() {

    }
}
