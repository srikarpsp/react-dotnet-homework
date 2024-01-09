import { Form, redirect, useLoaderData } from "react-router-dom";
import { ContactType } from "../types";
import PrimaryFormButton from "../components/PrimaryFormButton";

export default function Contact() {
    const { contact } = useLoaderData() as { contact: ContactType };

  return (
    <div id="contact" className="flex space-x-5">
      <div>
        <img
          key={contact.avatar}
          src={contact.avatar || undefined}
        />
      </div>

      <div>
        <h1 className="text-lg font-bold">
          {contact.name ? (
            <>
              {contact.name}
            </>
          ) : (
            <i>No Name</i>
          )}{" "}
        </h1>

        {contact.twitter && (
          <p className="italic">
            <a
              target="_blank"
              href={`https://twitter.com/${contact.twitter}`}
            >
              {contact.twitter}
            </a>
          </p>
        )}

        {contact.email && (
          <p>
            <a
              href="#"
            >
              {contact.email}
            </a>
          </p>
        )}

        {contact.phone && (
          <p>
            <a
              href="#"
            >
              {contact.phone}
            </a>
          </p>
        )}

        {contact.notes && <p>{contact.notes}</p>}

        {contact.address && <p>{contact.address}</p>}

        <div className="flex space-x-2 rounded-md bg-cyan-100 p-2 mt-2">
          <Form action="edit">
            <PrimaryFormButton>Edit</PrimaryFormButton>
          </Form>
          
          <Form
            method="post"
            action="delete"
            onSubmit={(event) => {
              if (
                !confirm(
                  "Please confirm you want to delete this record."
                )
              ) {
                event.preventDefault();
              }
            }}
          >
            <PrimaryFormButton>Delete</PrimaryFormButton>
          </Form>
        </div>
      </div>
    </div>
  );
}
interface ActionParams {
  contactId: number;
}

export async function deleteAction({
  params,
}: {
  params: ActionParams;
}) {
  await fetch(`/api/contacts/${params.contactId}`, {
    method: "DELETE",
  });

  return redirect(`/`);
}


export async function loader({ params }: { params: { contactId: string } }) {
    console.log("params = ", params);
    const contact = await fetch(`/api/contacts/${params.contactId}`).then(res => res.json());
    console.log("loaded the contact = ", contact);

    return { contact };

}
