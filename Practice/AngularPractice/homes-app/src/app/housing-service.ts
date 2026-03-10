import {Injectable} from '@angular/core';
import {HousingLocationInfo} from './housinglocation';
@Injectable({
  providedIn: 'root',
})
export class HousingService {
  url = 'http://localhost:3000/locations';
  async getAllHousingLocations(): Promise<HousingLocationInfo[]> {
    const data = await fetch(this.url);
    return (await data.json()) ?? [];
  }
async getHousingLocationById(id: number): Promise<HousingLocationInfo | undefined> {
  const homes = await this.getAllHousingLocations();
  return homes.find(home => Number(home.id) === id);
}
  submitApplication(firstName: string, lastName: string, email: string) {
    // tslint:disable-next-line
    console.log(firstName, lastName, email);
  }
}