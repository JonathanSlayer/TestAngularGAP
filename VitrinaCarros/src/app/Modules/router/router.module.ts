/*Modules*/
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Route, RouterModule } from '@angular/router';

/*Components*/
import { MainComponent } from '../../Components/ViewContainers/main/main.component';
import { DetailComponent } from '../../Components/ViewContainers/detail/detail.component';
import { CompareComponent } from '../../Components/ViewContainers/compare/compare.component';
const routes: Route[] = [
  { path: '', redirectTo: '/main', pathMatch: 'full' },
  { path: 'main', component: MainComponent },
  { path: 'detail/:id', component: DetailComponent },
  { path: 'compare', component: CompareComponent }
]
@NgModule({
  imports: [
    [RouterModule.forRoot(routes)]
  ],
  exports: [RouterModule]
})
export class appRoutingModule { }
