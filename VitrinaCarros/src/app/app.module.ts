/*Modules*/
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { appRoutingModule } from './Modules/router/router.module';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';

/*Components and pipes*/
import { AppComponent } from './app.component';
import { MainComponent } from './Components/ViewContainers/main/main.component';
import { CarThumbnailComponent } from './Components/car-thumbnail/car-thumbnail.component';
import { SortPipe } from './Pipes/sort/sort.pipe';
import { DetailComponent } from './Components/ViewContainers/detail/detail.component';
import { CarDetailComponent } from './Components/car-detail/car-detail.component';
import { CompareComponent } from './Components/ViewContainers/compare/compare.component';

/*Services */
import { DataStorageService } from './Services/DataStore/data-storage.service';

@NgModule({
  declarations: [
    AppComponent,
    MainComponent,
    CarThumbnailComponent,
    SortPipe,
    DetailComponent,
    CarDetailComponent,
    CompareComponent
  ],
  imports: [
    BrowserModule,
    appRoutingModule,
    HttpModule,
    FormsModule
  ],
  providers: [DataStorageService],
  bootstrap: [AppComponent]
})
export class AppModule { }

