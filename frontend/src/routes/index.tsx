import { useLoaderData } from "react-router-dom";
import { ContactType } from "../types";

import Contact from "../components/Contact";

export default function Index() {
    const { contacts } = useLoaderData() as { contacts: ContactType[] };
    console.log("contacts from loader hook = ", contacts);

    return (
        <div>
          {contacts.length ? (
            <ul className="flex flex-col lg:grid grid-cols-3 gap-4 mb-4">
              {contacts.map((contact) => <Contact contact={contact} key={contact.id} />)}
            </ul>
          ) : (
            <p>No contacts found.</p>
          )}
      
          <a href="contacts/add-contact" className="inline-block px-4 py-2 bg-green-500 text-white rounded-md">
            Add a new contact
          </a>
        </div>
      );
}

export async function loader() {
    const contacts = await fetch('/api/contacts').then(res => res.json());
    console.log("loaded the contacts = ", contacts);
    return { contacts };
}
