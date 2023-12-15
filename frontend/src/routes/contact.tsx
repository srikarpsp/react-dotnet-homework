import { Form } from "react-router-dom";
import { ContactType } from "../types";

export default function Contact() {
  const contact: ContactType = {
    name: "Bob Tester",
    avatar: "/avatars/headshot_1.png",
    email: "bob@test.com",
    phone: "1234567890",
    twitter: "your_handle",
    notes: "Some notes",
    guid: "1234"
  };

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

        {contact.notes && <p>{contact.notes}</p>}

        <div className="flex space-x-2 rounded-md bg-cyan-100 p-2 mt-2">
          <Form action="edit">
            <button type="submit">Edit</button>
          </Form>
          <Form
            method="post"
            action="destroy"
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
            <button type="submit">Delete</button>
          </Form>
        </div>
      </div>
    </div>
  );
}
