import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { Router } from '@angular/router';
import { DataStorageService } from '../../../Services/DataStore/data-storage.service';
import { Car } from '../../../Models/cars.model';

@Component({
  selector: 'app-compare',
  templateUrl: './compare.component.html',
  styleUrls: ['./compare.component.scss'],
  providers: []
})
export class CompareComponent implements OnInit {
  comapreIdList: Car[];
  constructor(private router:Router, private location: Location, private dataStorageService: DataStorageService) { }

  ngOnInit() {
    this.comapreIdList=[];
    if( this.dataStorageService.storage===undefined){
      this.router.navigate(['main']);
      return;
    }   
    this.comapreIdList = this.dataStorageService.storage;
  }
  goBack(): void {
    this.location.back();
  }
}
