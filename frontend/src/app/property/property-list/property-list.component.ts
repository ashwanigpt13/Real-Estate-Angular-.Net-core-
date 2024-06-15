import { Component, OnInit, ViewChild } from '@angular/core';
import { HousingService } from 'src/app/services/housing.service';
import { Iproperty } from '../Iproperty.interface';
import { ActivatedRoute } from '@angular/router';
import { TabsetComponent } from 'ngx-bootstrap/tabs';
import { IpropertyBase } from 'src/app/model/IpropertyBase';

@Component({
  selector: 'app-property-list',
  templateUrl: './property-list.component.html',
  styleUrls: ['./property-list.component.css']
})
export class PropertyListComponent implements OnInit{
  SellRent=1;
  properties: IpropertyBase[] = [];
  City = '';
  SearchCity = '';
  SortbyParam = '';
  SortDirection = 'asc';
  constructor(private route:ActivatedRoute,private housingService:HousingService){}

  ngOnInit(): void{
    if(this.route.snapshot.url.toString()){
      this.SellRent=2;
    }
    this.housingService.getAllProperties(this.SellRent).subscribe(
      (data:any[])=>{
        console.log(data);
        this.properties=data;
        console.log(this.properties, " test ", localStorage.getItem('Newprop'))
        // if(localStorage.getItem('Newprop')){
        //   const newproperty = JSON.parse(localStorage.getItem('Newprop')!);
        //   console.log(newproperty, " test")
        //   if(newproperty.SellRent===this.SellRent){
        //     this.properties=[newproperty, ...this.properties];
        //   }
        // }       
        
        console.log(data);
        console.log(this.route.snapshot.url.toString());
      },error=>{
        console.log(error);
      }
    );
  }
  onCityFilter() {
    this.SearchCity = this.City;
  }

  onCityFilterClear() {
    this.SearchCity = '';
    this.City = '';
  }

  onSortDirection() {
    if (this.SortDirection === 'desc') {
      this.SortDirection = 'asc';
    } else {
      this.SortDirection = 'desc';
    }
  }
  
}
