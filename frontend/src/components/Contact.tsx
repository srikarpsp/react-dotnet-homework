import { UserIcon } from '@heroicons/react/24/outline';
import { ContactType } from '../types';
import { Link } from 'react-router-dom';

export default function Contact({ contact }: { contact: ContactType }): JSX.Element {
    const Icon = UserIcon;

    return <Link to={`contacts/${contact.id}`}>
            <div
              className="relative overflow-hidden rounded-lg bg-white px-4 pb-12 pt-5 shadow sm:px-6 sm:pt-6"
            >
              <dt>
                <div className="absolute rounded-md bg-indigo-500 p-3">
                  <Icon className="h-6 w-6 text-white" aria-hidden="true" />
                </div>
                <p className="ml-16 truncate text-sm font-medium text-gray-500">@{contact.twitter}</p>
              </dt>
              <dd className="ml-16 flex flex-col items-baseline pb-6 sm:pb-7">
                <p className="text-2xl font-semibold text-gray-900">{contact.name}</p>
                <p className="ml-2">
                  {contact.email}
                </p>
                <div className="absolute inset-x-0 bottom-0 bg-gray-50 px-4 py-4 sm:px-6">
                  <div className="text-sm">
                    <a href="#" className="font-medium text-indigo-600 hover:text-indigo-500">
                      Delete
                    </a>
                  </div>
                </div>
              </dd>
            </div>
           </Link>
}
