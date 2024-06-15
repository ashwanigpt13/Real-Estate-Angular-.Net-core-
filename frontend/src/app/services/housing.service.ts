import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Iproperty } from '../property/Iproperty.interface';
import { Property } from '../model/property';
import { Ikeyvaluepair } from '../model/ikeyvaluepair';
@Injectable({
  providedIn: 'root'
})
export class HousingService {

  constructor(private http: HttpClient) { }

  getAllCities(): Observable<string[]>{
    return this.http.get<string[]>( 'https://localhost:7272/api/City/cities');
  }
  getProperty(id:number){
    return this.http.get<Property[]>('https://localhost:7272/api'+'/property/detail/'+ id?.toString());
  }

  getAllProperties(SellRent?:number):Observable<Property[]>{
    return this.http.get<Property[]>('https://localhost:7272/api'+'/property/list/'+ SellRent?.toString());
  }
  getPropertyType():Observable<Ikeyvaluepair[]>{
    return this.http.get<Ikeyvaluepair[]>('https://localhost:7272/api'+'/propertytype/list/');
  }
  getFurnishingType():Observable<Ikeyvaluepair[]>{
    return this.http.get<Ikeyvaluepair[]>('https://localhost:7272/api'+'/furnishingtype/list/');
  }

  addProperty(property:Property){
    const token = localStorage.getItem('token');
  
    // Check if the token is present
    if (!token) {
      console.error('Token not found in localStorage');
      return;
    }
  
    // Create the HttpHeaders with the Authorization header
    const httpOptions = {
      headers: new HttpHeaders({
        'Authorization': `Bearer ${token}`
      })
    };
   return this.http.post('https://localhost:7272/api'+'/property/add',property,httpOptions);
  }

  newPropID() {
    let currentID: number;

    const storedPID = localStorage.getItem('PID');

    if (storedPID) {
        currentID = +storedPID + 1;
    } else {
        currentID = 101;
    }

    localStorage.setItem('PID', String(currentID));
    return currentID;
}

getPropertyAge(dateofEstablishment:Date): string{
  const today = new Date();
        const estDate = new Date(dateofEstablishment);
        let age = today.getFullYear() - estDate.getFullYear();
        const m = today.getMonth() - estDate.getMonth();

        // Current month smaller than establishment month or
        // Same month but current date smaller than establishment date
        if (m < 0 || (m === 0 && today.getDate() < estDate.getDate())) {
            age --;
        }

        // Establshment date is future date
        if(today < estDate) {
            return '0';
        }

        // Age is less than a year
        if(age === 0) {
            return 'Less than a year';
        }

        return age.toString();
}


setPrimaryPhoto(propertyId: number, propertyPhotoId: string) {
  const httpOptions = {
      headers: new HttpHeaders({
          Authorization: 'Bearer '+ localStorage.getItem('token')
      })
  };
  return this.http.post('https://localhost:7272/api'+ '/property/set-primary-photo/'+String(propertyId)
      +'/'+propertyPhotoId, {}, httpOptions);
}

deletePhoto(propertyId: number, propertyPhotoId: string) {
  const httpOptions = {
      headers: new HttpHeaders({
          Authorization: 'Bearer '+ localStorage.getItem('token')
      })
  };
  return this.http.delete('https://localhost:7272/api'+ '/property/delete-photo/'+String(propertyId)
      +'/'+propertyPhotoId, httpOptions);
}

}
