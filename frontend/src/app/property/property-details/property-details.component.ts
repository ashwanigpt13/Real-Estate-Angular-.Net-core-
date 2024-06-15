import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Property } from 'src/app/model/property';
import { HousingService } from 'src/app/services/housing.service';
import {NgxGalleryOptions} from '@kolkov/ngx-gallery';
import {NgxGalleryImage} from '@kolkov/ngx-gallery';
import {NgxGalleryAnimation} from '@kolkov/ngx-gallery';

@Component({
  selector: 'app-property-details',
  templateUrl: './property-details.component.html',
  styleUrls: ['./property-details.component.css']
})
export class PropertyDetailsComponent implements OnInit {
  galleryOptions!: NgxGalleryOptions[];
  galleryImages!: NgxGalleryImage[];
  public propertyId!: number;
  property= new Property();
  public mainPhotoUrl: string = "";
  constructor(private route: ActivatedRoute ,
              private router:Router,
              private housingService: HousingService){  }

  ngOnInit(): void {
    this.propertyId = +this.route.snapshot.params['id'];

    this.route.params.subscribe(
      (params)=>{
        this.propertyId= +params['id'];
        this.housingService.getProperty(this.propertyId).subscribe(
          (data: any)=>{
            this.property=data;
            console.log(this.property,  " mxshdvhgc")
            this.galleryImages=this.getPropertyPhotos();
          }
        )
      }
    );

    if (this.property.estPossessionOn) {
     // this.property.age = this.housingService.getPropertyAge(new Date(this.property.estPossessionOn));
  
    }
      //============================
    this.galleryOptions = [
      {
        width: '100%',
        height: '460px',
        thumbnailsColumns: 4,
        imageAnimation: NgxGalleryAnimation.Slide,
        preview:true
      },
    ];
    this.galleryImages=this.getPropertyPhotos();
  }

  changePrimaryPhoto(mainPhotoUrl:string){
    this.mainPhotoUrl=mainPhotoUrl;
  }

  getPropertyPhotos(): NgxGalleryImage[] {
    const photoUrls: NgxGalleryImage[] = [];
    
    if (this.property && this.property.photos) {
      for (const photo of this.property.photos) {
        if(photo.isPrimary){
          this.mainPhotoUrl=photo.imageUrl;
        }
        photoUrls.push({
          small: photo.imageUrl,
          medium: photo.imageUrl,
          big: photo.imageUrl
        });
      }
    }
    
    console.log("Iterable Imagers",photoUrls);
    return photoUrls;
  }
  
  checkForEMpty(){
    console.log(this.property, " prop ")
    return this.property && Object.keys(this.property).length !== 0;
  }

}
