import React from 'react';

interface PrimaryActionProps {
  href: string;
  children: React.ReactNode;
}

const PrimaryAction: React.FC<PrimaryActionProps> = ({ href, children }) => {
  return (
    <a
      href={href}
      className="inline-block px-4 py-2 rounded-md bg-indigo-600 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
    >
      {children}
    </a>
  );
};

export default PrimaryAction;