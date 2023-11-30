import { CityType } from '../types';

export default function City({ city }: { city: CityType }): JSX.Element {
    return <li>{city.city}: {city.temperature} and {city.conditions}</li>
}
