import { IpropertyBase } from "./IpropertyBase";
import { Photo } from "./Photo";

export class Property implements IpropertyBase {
  id!: number;
  sellRent!: number;
  name!: string;
   propertyTypeId!: number;
  propertyType!: string;
  bhk!: number;
  furnishingTypeId!: number;
  furnishingType!: string;

  price!: number;
  builtArea!: number;
  carpetArea?: number;
  address!: string;
  address2?: string;
  //CityId!:number;
  CityId!: string;
  floorNo?: number;
  totalFloors?: number;
  readyToMove!: boolean;
  age?: number;
  mainEntrance?: string;
  security?: number;
  gated?: boolean;
  maintenance?: number;
  estPossessionOn?: Date;
  image?: string;
  description?: string;
  photos?: Photo[];
}