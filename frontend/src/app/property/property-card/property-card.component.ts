import { Component,Input } from "@angular/core";
import { Iproperty } from "../Iproperty.interface";
import { IpropertyBase } from "src/app/model/IpropertyBase";
import { FormGroup } from "@angular/forms";

@Component(
    {
    selector:'app-property-card',
    templateUrl: 'property-card.component.html',
    styleUrls: ['property-card.component.css']   
    }
)
export class PropertyCardCompenent{

@Input() hideIcons!: Boolean; 
//@Input() addPropertyForm1!:FormGroup;
@Input() property !: IpropertyBase;


// ngOnInit(){
//     if(this.addPropertyForm1){
//    const nn=this.addPropertyForm1.controls['BasicInfo'] as FormGroup;
// }
}

// ngOnChanges(){
  
//         // const BasicInfo=this.addPropertyForm1.controls['BasicInfo']  as FormGroup;
//         // this.property=BasicInfo.controls.value as IpropertyBase;
//      console.log(this.addPropertyForm1)
//             if(this.addPropertyForm1){
//                 const basicinfo=this.addPropertyForm1.controls['BasicInfo'] as FormGroup;
//              const PriceInfo=this.addPropertyForm1.controls['PriceInfo'] as FormGroup;
//             this.property.propertyTypeId=basicinfo.controls['propertyType'].value;
//             this.property.name=basicinfo.controls['name'].value;
//             this.property.furnishingTypeId=basicinfo.controls['furnishingType'].value;
//             this.property.city=basicinfo.controls['city'].value;
//             this.property.bhk=basicinfo.controls['bhk'].value;
//             this.property.sellRent=basicinfo.controls['sellRent'].value;
        
//             this.property.builtArea=PriceInfo.controls['builtArea'].value;
//             this.property.price=PriceInfo.controls['price'].value;
//             }
        
          
    
// }
//}