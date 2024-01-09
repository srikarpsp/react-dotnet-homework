// PrimaryFormButton.tsx
import React from 'react';

interface PrimaryFormButtonProps {
    children: React.ReactNode;
  }
const PrimaryFormButton: React.FC<PrimaryFormButtonProps> = ({ children }) => {
    return(<button type="submit" className="inline-block px-4 py-2 rounded-md bg-indigo-600 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600">{children}</button>)
  }

export default PrimaryFormButton;
