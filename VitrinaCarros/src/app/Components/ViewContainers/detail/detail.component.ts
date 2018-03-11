import { Component, OnInit, Input } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { CarServiceService } from '../../../Services/CarService/car-service.service';

import { Car } from '../../../Models/cars.model';
@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.scss'],
  providers: [CarServiceService]
})
export class DetailComponent implements OnInit {
  @Input() id1: string;
  @Input() id2: string;
  car: Car;
  constructor(private carServiceService: CarServiceService, private location: Location, private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    const id = +this.activatedRoute.snapshot.params['id'];
      this.getCarById(id);
  }

  getCarById(id): void {
    this.carServiceService.getCarbyId(id).subscribe(car => this.car = car);
  }

  goBack(): void {
    this.location.back();
  }
}
