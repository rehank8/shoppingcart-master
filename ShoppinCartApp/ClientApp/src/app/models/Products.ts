export class products {
  id: any;
  productName: string;
  image: string;
  category: string;
  fKSubCategoryId: string;
  fKCategoryId: string;
  subCategory: string;
  price: number;
  isActive: boolean;
  color: string;
  features: string;
  description: string;
  rating: number;
  condition: string;
  fKBrandId: string;
  isAvailability: boolean;
}

export class PaymentDetails {
  UserId: string;
  Amount: number;
}
