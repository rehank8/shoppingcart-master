export class Category {
  id: string;
  categoryName: string;
  subCategories: SubCategory[] = [];
}


export class SubCategory {
  id: string;
  subCategoryName: string;
  fKCategoryId: string;
}
