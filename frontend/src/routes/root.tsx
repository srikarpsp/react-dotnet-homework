import { useLoaderData } from "react-router-dom";

export default function Root() {
    const { cities } = useLoaderData();
    console.log("cities from loader hook = ", cities);

    return <>
     <h1>Hello from Root!</h1>
     { cities.length ? (
        <ul>
            { cities.map((city: any) => (
                <li key={city}>{city.city}: {city.temperature} and {city.conditions}</li>
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
