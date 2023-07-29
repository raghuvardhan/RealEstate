export interface Property {
    id: number;
    title: string;
    price: number;
    location: string;
    propertyType: string;
    numberOfBedrooms: number;
    numberOfBathrooms: number;
    description: string;
    lat?: number;
    lng?: number;
  }
  