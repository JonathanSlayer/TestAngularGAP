export class Car {
    id: number;
    img: string;
    model: number;
    year: number;
    brand: string;
    price: number;
    compareCheck: boolean;
    detail: CarDetail;
    outstanding:boolean;
    showalert:boolean;
}

export class CarDetail {
    description: string;
    contactName: string;
    Phone: number;
}