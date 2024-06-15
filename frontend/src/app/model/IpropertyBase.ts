export interface IpropertyBase{
    
    id:number;
    sellRent: number;
    name:string;
    propertyType:string;
    //FurnishingTypeId:number;
   // PropertyTypeId:number;
    furnishingType:string;
    price: number;
    bhk: number;
    builtArea: number;
    //city: string;
    CityId:string;
    readyToMove :boolean;
    photo?: string;
    estPossessionOn?: Date;

    // Security?:number;
    // Maintenance?:number;
    // CarpetArea?:number;
    // FloorNo?:string;
    // TotalFloor?:string;
    // Address?:string;
   
    // Gated?:number;
    // MainEntrance?:string;

}