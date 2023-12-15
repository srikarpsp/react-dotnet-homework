import { render, screen } from '@testing-library/react';
import Contact from './Contact';
import { ContactType } from '../types';

describe('<Contact />', () => {
  const contact: ContactType = {
    name: 'John Doe',
    email: 'john@doe.com',
    phone: '1234567890',
    guid: '1234',
  };

  it('renders name', async () => {
    render(<Contact contact={contact} />);

    const item = await screen.getByText(contact.name);

    expect(item).not.toBeNull();
  });

  it('renders email', async () => {
    render(<Contact contact={contact} />);

    const item = await screen.getByText(contact.email);

    expect(item).not.toBeNull();
  });

  it('renders phone', async () => {
    render(<Contact contact={contact} />);

    const item = await screen.getByText(contact.phone);

    expect(item).not.toBeNull();
  });
});
