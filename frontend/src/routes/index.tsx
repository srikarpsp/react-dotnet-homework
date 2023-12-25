import { useLoaderData } from "react-router-dom";
import { ContactType } from "../types";

import Contact from "../components/Contact";

export default function Index() {
    const { contacts } = useLoaderData() as { contacts: ContactType[] };
    console.log("contacts from loader hook = ", contacts);

    return contacts.length ? (
        <ul className="flex flex-col lg:grid grid-cols-3 gap-4">
            {contacts.map((contact) => <Contact contact={contact} key={contact.id} />)}
            <a href="contacts/add-contact"> Add a new contact</a>
        </ul>
    ) : (
        <p>No contacts found.</p>
    );
}

export async function loader() {
    const contacts = await fetch('/api/contacts').then(res => res.json());
    console.log("loaded the contacts = ", contacts);
    return { contacts };
}
