import { Component, OnInit } from '@angular/core';
import { CarServiceService } from '../../../Services/CarService/car-service.service';
import { DataStorageService } from '../../../Services/DataStore/data-storage.service';
import { Car } from '../../../Models/cars.model';
import { Router } from '@angular/router';
import { element } from 'protractor';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss'],
  providers: [CarServiceService]
})
export class MainComponent implements OnInit {
  carList: Car[];
  filterText: string = "";
  comapreIdList: Car[];
  disableCompareBtn: boolean = true;
  constructor(private ngbModal: NgbModal, private dataStorageService: DataStorageService, private carServiceService: CarServiceService, private router: Router) { }

  ngOnInit() {
    this.comapreIdList = [];
    this.getCarList();
  }

  getCarList() {
    this.carServiceService.getCarJSON().subscribe(carlist => this.carList = carlist);
  }

  filterByBrand(newModel) {
    if (newModel == '') {
      this.getCarList();
      return;
    }
    this.carList = this.carList.filter(
      car => car.brand.toUpperCase().search(newModel.toUpperCase()) != -1);
  }

  onClickcompareCars() {
    this.dataStorageService.storage = this.comapreIdList;
    this.router.navigate(['compare']);
  }

  compareCars(car) {
    setTimeout(() => {
      if (this.comapreIdList.length >= 3) {
        let idx = this.carList.findIndex(i => i.id == car.id);
        if (idx != -1) {
          if (!this.carList[idx].compareCheck) {
            let idx2 = this.comapreIdList.findIndex(i => i.id == car.id);
            if (idx2 != -1) {
              this.comapreIdList.splice(idx2, 1);
            }
          } else {
            this.carList[idx].compareCheck = false;
          }
        }
      } else {
        this.comapreIdList.push(car);
      }
      if (this.comapreIdList.length == 2 || this.comapreIdList.length == 3) {
        this.disableCompareBtn = false;
      }
    });

  }
}
