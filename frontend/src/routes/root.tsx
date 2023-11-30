import { useLoaderData } from "react-router-dom";

type City = {
    guid: string;
    city: string;
    temperature: number;
    conditions: string;
};

export default function Root() {
    const { cities } = useLoaderData() as { cities: City[] };
    console.log("cities from loader hook = ", cities);

    return <>
     <h1>Hello from Root!</h1>
     { cities.length ? (
        <ul>
            { cities.map((city) => (
                <li key={city.guid}>{city.city}: {city.temperature} and {city.conditions}</li>
            )) }
        </ul>
        ) : (
            <p>No cities found.</p>
        )
     }
    </>
}

export async function loader() {
    const cities = await fetch('/api/cities').then(res => res.json());
    console.log("loaded these cities = ", cities);
    return { cities };
}
