export interface ImageOfShoe {
  id: number;
  url: string;
  imageType: string;
  esprincipal: boolean;
}

export interface Zapato {
  id: number;
  model: string;
  price: number;
  size: number;
  categoryid: number;

  category: {
    id: number;
    name: string;
  };

  imageofshoes: ImageOfShoe[];  
}