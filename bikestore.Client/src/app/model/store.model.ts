export class Store {
  id!: number;
  name!: string;
  phone!: string | null;
  email!: string | null;
  street!: string | null;
  city!: string | null;
  state!: string | null;
  zipCode!: string | null;

  constructor(init?: Partial<Store>) {
    Object.assign(this, init);
  }
}
