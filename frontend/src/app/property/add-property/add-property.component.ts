import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TabsetComponent } from 'ngx-bootstrap/tabs/public_api';
import { Iproperty } from 'src/app/model/Iproperty';
import { IpropertyBase } from 'src/app/model/IpropertyBase';
import { FormControl } from '@angular/forms';
import { Property } from 'src/app/model/property';
import { HousingService } from 'src/app/services/housing.service';
import { AlertifyService } from 'src/app/services/alertify.service';
import { Ikeyvaluepair } from 'src/app/model/ikeyvaluepair';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-add-property',
  templateUrl: './add-property.component.html',
  styleUrls: ['./add-property.component.css']
})
export class AddPropertyComponent implements OnInit{
//@ViewChild('Form') addProperyForm! : NgForm;
@ViewChild('formTabs') formTabs! : TabsetComponent;
// @Input() btnRadio!: string;  
// @Input() value!: string;  '
property=new Property();
addPropertyForm!: FormGroup;
NextClicked!: boolean;
propertyTypes!: Ikeyvaluepair[];
selectedPropertyType!: string;
selectedBhk!: string;
furnishingTypes!: Ikeyvaluepair[];

cityList!:any[];
selectedCity='';

propertyView: IpropertyBase= {
  
  id: 0,
  sellRent: 0,
  name:'',
  propertyType:"House",
  furnishingType:"Semi",
  //PropertyTypeId:0,
  //FurnishingTypeId:0,
  price: 0,
  bhk: 0,
  builtArea:0,
  //city:'',
  CityId:'',
  readyToMove:false,

};
constructor(private datepipe:DatePipe,
            private fb: FormBuilder,
            private router:Router,
            private housingServices: HousingService,
            private alertify: AlertifyService){
              
            }

  ngOnInit(): void {
    if(!localStorage.getItem('userName'))
      {
        this.alertify.error('You must be logged in to add a property');
        this.router.navigate(['/user/login']);
      }
   this.CreateAddPropertyForm();
    this.housingServices.getAllCities().subscribe((data: string[])=>{
      console.log("List of Cities",data);
      this.cityList=data;
      
    })
    this.addPropertyForm.valueChanges.subscribe(newval=>{
         
         })


  //  this.addPropertyForm.valueChanges.subscribe(value => {
  //   this.propertyView = {
  //     id: value.Id,
  //   sellRent: value.SellRent,
  //   name: value.Name,
  //   propertyType: value.PType,
  //   furnishingType: value.FType,
  //   bhk: 0,
  //   builtArea: 1,
  //   price: 0,
  //   city: '',
  //   readyToMove: 0,
  //   };})

  //   this.mapProperty();
  this.housingServices.getPropertyType().subscribe(data=>{
    this.propertyTypes=data;
  });
  this.housingServices.getFurnishingType().subscribe(data=>{
    this.furnishingTypes=data;
  });
  }

  ngOnChanges(){
    console.log(this.addPropertyForm, " add property")
    this.addPropertyForm.valueChanges.subscribe(newval=>{
    
    })
  }

  // ngOnChanges(){
  //   this.CreateAddPropertyForm();
  //   // this.addPropertyForm.valueChanges.subscribe(value => {
  //   //   this.propertyView = {
  //   //     Id: value.Id,
  //   //   SellRent: value.SellRent,
  //   //   Name: value.Name,
  //   //   PType: value.PType,
  //   //   FType: value.FType,
  //   //   BHK: 0,
  //   //   BuiltArea: 1,
  //   //   Price: 0,
  //   //   City: '',
  //   //   RTM: 0,
  //   //   };})
  // }
  CreateAddPropertyForm(){
    this.addPropertyForm=this.fb.group({
      BasicInfo: this.fb.group({
        sellRent: ['1' , Validators.required],
        bhk: [null, Validators.required],
        propertyType: [null, Validators.required],
        furnishingType: [null, Validators.required],
        name: [null, Validators.required],
        city: [null, Validators.required]
      }),
      PriceInfo: this.fb.group({
        price: [0, Validators.required],
        builtArea: [0, Validators.required],
        carpetArea: [0],
        security: [0],
        maintenance: [0],
      }),

      AddressInfo: this.fb.group({
        floorNo: [0],
        totalFloor: [0],
        address: [null, Validators.required],
        landMark: [null],
      }),

      OtherInfo: this.fb.group({
        readyToMove: [null, Validators.required],
        possessionOn: [null],
        age: [null],
        gated: [null],
        mainEntrance: [null],
        description: [null]
      })

    //   SellRent:[null,Validators.required],
    //   PType:[null,Validators.required],
    //   Name:[null,Validators.required],
    //   City:[null,Validators.required],
    //   Price:[null,Validators.required],
    //   BuiltArea:[null,Validators.required],
    //  // price:[null,Validators.required],
    //   FType:[null,Validators.required],
    //   BHK:[null,Validators.required]
    });
  }

  mapProperty(): void {
    this.property.id = this.housingServices.newPropID();
    this.property.sellRent = +this.SellRent.value;
    this.property.bhk = this.BHK.value;
    this.property.propertyTypeId=this.PType.value;
    // this.property.propertyTypeId = this.PType.value;
    this.property.name = this.Name.value;
    this.property.CityId = this.City.value;
    //this.property.furnishingType=this.FType.value;
     this.property.furnishingTypeId = this.FType.value;
    this.property.price = this.Price.value;
    
     this.property.security = this.Security.value;
     this.property.maintenance = this.Maintenance.value;
     this.property.builtArea = this.BuiltArea.value;
     this.property.carpetArea = this.CarpetArea.value;
     this.property.floorNo = this.FloorNo.value;
    this.property.totalFloors = this.TotalFloor.value;
    this.property.address = this.Address.value;
    this.property.address2=this.LandMark.value;
    this.property.readyToMove = this.RTM.value;
    this.property.gated = this.Gated.value;
    this.property.mainEntrance = this.MainEntrance.value;
  
    this.property.estPossessionOn =this.PossessionOn.value;
    this.property.description = this.Description.value;
}

  //#region <Getter Methods>
  // #region <FormGroups>
  get BasicInfo() {
    return this.addPropertyForm.controls['BasicInfo'] as FormGroup;
  }
  

  get PriceInfo() {
    return this.addPropertyForm.controls['PriceInfo'] as FormGroup;
  }

  get AddressInfo() {
    return this.addPropertyForm.controls['AddressInfo'] as FormGroup;
  }

  get OtherInfo() {
    return this.addPropertyForm.controls['OtherInfo'] as FormGroup;
  }
// #endregion

//#region <Form Controls>
get SellRent() {
  return this.BasicInfo.controls['sellRent'] as FormControl;
}

get BHK() {
  return this.BasicInfo.controls['bhk'] as FormControl;
}

get PType() {
  return this.BasicInfo.controls['propertyType'] as FormControl;
}

get FType() {
  return this.BasicInfo.controls['furnishingType'] as FormControl;
}

get Name() {
  return this.BasicInfo.controls['name'] as FormControl;
}

get City() {
  return this.BasicInfo.controls['city'] as FormControl;
}

get Price() {
  return this.PriceInfo.controls['price'] as FormControl;
}

get BuiltArea() {
  return this.PriceInfo.controls['builtArea'] as FormControl;
}

get CarpetArea() {
  return this.PriceInfo.controls['carpetArea'] as FormControl;
}

get Security() {
  return this.PriceInfo.controls['security'] as FormControl;
}

get Maintenance() {
  return this.PriceInfo.controls['maintenance'] as FormControl;
}

get FloorNo() {
  return this.AddressInfo.controls['floorNo'] as FormControl;
}

get TotalFloor() {
  return this.AddressInfo.controls['totalFloor'] as FormControl;
}

get Address() {
  return this.AddressInfo.controls['address'] as FormControl;
}

get LandMark() {
  return this.AddressInfo.controls['landMark'] as FormControl;
}

get RTM() {
  return this.OtherInfo.controls['readyToMove'] as FormControl;
}

get PossessionOn() {
  return this.OtherInfo.controls['possessionOn'] as FormControl;
}

// get AOP() {
//   return this.OtherInfo.controls['AOP'] as FormControl;
// }

get Gated() {
  return this.OtherInfo.controls['gated'] as FormControl;
}

get MainEntrance() {
  return this.OtherInfo.controls['mainEntrance'] as FormControl;
}

get Description() {
  return this.OtherInfo.controls['description'] as FormControl;
}


//#endregion
//#endregion
  OnBack(){
    this.router.navigate(['/']);
  }

  OnSubmit(){
    this.NextClicked=true;
    if(this.allTabsValid()){
      this.mapProperty();
      console.log(this.property)
      // var data = {
      // id:1,
      // sellRent:1,
      // cityId: 1,
      // estPossessionOn: new Date(),
      // address:"New Address",
      // bhk: 1,
      // builtArea: 234,
      // city: "Chandigarh",
      // furnishingTypeId: 1,
      // name:" test",
      // price: 2000,
      // propertyTypeId: 1,
      // readyToMove: true,
      // address2: " add",
      // carpetArea: 1290,
      // description: " test",
      // floorNo: 12,
      // gated: true,
      // mainEntrance: "yes",
      // maintenance: 12909,
      // security: 2000,
      // totalFloors:  22,
      // age: 29
      // } as Property;
      this.property.gated=true;
      this.housingServices.addProperty(this.property)!.subscribe(
        ()=>{
          this.alertify.success("Congrats!!! Your Property is lisited")
          console.log(this.addPropertyForm)
   
          if(this.SellRent.value==='2')
           {
             this.router.navigate(['/rent-property']);
           }
           else{
             this.router.navigate(['/']);
           }
        }
      );
    
    }
    else
    {
      this.alertify.error('Please fill the form correctly!!!')
    }
  }

  allTabsValid(): boolean {
    if (this.BasicInfo.invalid) {
      console.log('tab1-Data',this.BasicInfo);
      this.formTabs.tabs[0].active = true;
      return false;
    }

    if (this.PriceInfo.invalid) {
      console.log('tab2-Data',this.PriceInfo);
      this.formTabs.tabs[1].active = true;
      return false;
    }

    if (this.AddressInfo.invalid) {
      console.log('tab3-Data',this.AddressInfo);
      this.formTabs.tabs[2].active = true;
      return false;
    }

    if (this.OtherInfo.invalid) {
      console.log('tab4-Data',this.OtherInfo);
      this.formTabs.tabs[3].active = true;
      return false;
    }
    return true;
  }
  // convertToDate(dateString: string): Date {
  //   console.log(new Date(dateString))
  //   return new Date(dateString);}
  updatePossessionDate(value: string): void {
    this.propertyView.estPossessionOn = new Date(value);
    console.log(this.propertyView.estPossessionOn);
  }

  selectTab(tabId:number,IsCurrentTabValid:boolean){
    this.NextClicked=true;
    if(IsCurrentTabValid){
    this.formTabs.tabs[tabId].active=true;
    }
    console.log("Tabno-",tabId)
  }
  
}
