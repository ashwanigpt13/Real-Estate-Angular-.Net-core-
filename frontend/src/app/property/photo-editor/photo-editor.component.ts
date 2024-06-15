import { Component, OnInit,Input, EventEmitter, Output, Directive, OnChanges, SimpleChanges, } from '@angular/core';
import { FileUploader } from 'ng2-file-upload';
import { Photo } from 'src/app/model/Photo';

import { Property } from 'src/app/model/property';
import { AlertifyService } from 'src/app/services/alertify.service';
import { HousingService } from 'src/app/services/housing.service';


@Component({
  selector: 'app-photo-editor',
  templateUrl: './photo-editor.component.html',
  styleUrls: ['./photo-editor.component.css'],
  
})

export class PhotoEditorComponent  implements OnInit, OnChanges{
  @Input() property: Property = new Property;
  @Output() mainPhotoChangeEvent = new EventEmitter<string>();
  uploader!: FileUploader;
  baseUrl='https://localhost:7272/api';
  maxAllowedSize=10*1024*1024;
  constructor(private housingService: HousingService,private alertify : AlertifyService){} 

//   public fileOverBase(e: any): void {
//     this.hasBaseDropZoneOver = e;
// }
  initializeFileUploader(){
    console.log(this.property, " test")
    this.uploader = new FileUploader({
      url:this.baseUrl+'/Property/add/photo/'+ String(this.property?.id),
      authToken: 'Bearer '+ localStorage.getItem('token'),
      isHTML5:true,
      allowedFileType:['image'],
      removeAfterUpload:true,
      autoUpload:true,
      maxFileSize:this.maxAllowedSize
    });
    this.uploader.onAfterAddingFile=(file)=>{
      file.withCredentials=false;
    }
    this.uploader.onSuccessItem=(item,response,status,headers)=>
    {
      console.log("hgdfxs", item, response, status, headers)
      if(response){
        console.log(response, " resa")
        const photo = JSON.parse(response);
         this.property.photos!.push(photo);
      }
    };

    this.uploader.onErrorItem = (item, response, status, headers) => {
      let errorMessage = 'Some unknown error occured';
      if (status===401) {
          errorMessage ='Your session has expired, login again';
      }

      if (response) {
          errorMessage = response;
      }

      this.alertify.error(errorMessage);
  };
  }

  mainPhotoChanged(url: string){
    this.mainPhotoChangeEvent.emit(url);
  }
  ngOnInit():void{
    this.initializeFileUploader();
    console.log(this.property);
  }

setPrimaryPhoto(propertyId:number,photo:Photo){
   this.housingService.setPrimaryPhoto(propertyId,photo.publicid).subscribe(()=>{
   this.mainPhotoChanged(photo.imageUrl);
    this.property.photos?.forEach(p=>{
    if(p.isPrimary){p.isPrimary=false;}
    if(p.publicid===photo.publicid){p.isPrimary=true;}
   });
  });
}

deletePhoto(propertyId:number,photo:Photo){
  this.housingService.deletePhoto(propertyId,photo.publicid).subscribe(()=>{
 this.property.photos=this.property.photos?.filter(p=>
  p.publicid!==photo.publicid);
 });
}

ngOnChanges(changes: SimpleChanges): void {
  this.initializeFileUploader();
}

}
