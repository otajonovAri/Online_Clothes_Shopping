import { Link } from 'react-router-dom'
import { BookOpen, Mail, Phone, MapPin, Facebook, Twitter, Instagram, Linkedin } from 'lucide-react'

export function Footer() {
  const currentYear = new Date().getFullYear()

  const footerLinks = {
    platform: [
      { name: 'Kurslar', href: '/courses' },
      { name: 'O\'qituvchilar', href: '/instructors' },
      { name: 'Talabalar', href: '/students' },
      { name: 'Biz haqimizda', href: '/about' },
    ],
    support: [
      { name: 'Yordam markazi', href: '/help' },
      { name: 'Bog\'lanish', href: '/contact' },
      { name: 'FAQ', href: '/faq' },
      { name: 'Texnik yordam', href: '/support' },
    ],
    legal: [
      { name: 'Maxfiylik siyosati', href: '/privacy' },
      { name: 'Foydalanish shartlari', href: '/terms' },
      { name: 'Cookie siyosati', href: '/cookies' },
      { name: 'Huquqiy ma\'lumotlar', href: '/legal' },
    ],
  }

  const socialLinks = [
    { name: 'Facebook', icon: Facebook, href: '#' },
    { name: 'Twitter', icon: Twitter, href: '#' },
    { name: 'Instagram', icon: Instagram, href: '#' },
    { name: 'LinkedIn', icon: Linkedin, href: '#' },
  ]

  return (
    <footer className="bg-secondary-900 text-white">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-12">
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-8">
          {/* Brand */}
          <div className="space-y-4">
            <Link to="/" className="flex items-center space-x-2">
              <div className="w-8 h-8 bg-primary-600 rounded-lg flex items-center justify-center">
                <BookOpen className="w-5 h-5 text-white" />
              </div>
              <span className="text-xl font-bold">EduFinder</span>
            </Link>
            <p className="text-secondary-300 text-sm leading-relaxed">
              EduFinder - zamonaviy ta'lim platformasi. Eng yaxshi kurslar va 
              professional o'qituvchilar bilan bilimingizni oshiring.
            </p>
            <div className="flex space-x-4">
              {socialLinks.map((social) => (
                <a
                  key={social.name}
                  href={social.href}
                  className="w-8 h-8 bg-secondary-800 rounded-lg flex items-center justify-center hover:bg-primary-600 transition-colors"
                  aria-label={social.name}
                >
                  <social.icon className="w-4 h-4" />
                </a>
              ))}
            </div>
          </div>

          {/* Platform Links */}
          <div>
            <h3 className="text-lg font-semibold mb-4">Platforma</h3>
            <ul className="space-y-2">
              {footerLinks.platform.map((link) => (
                <li key={link.name}>
                  <Link
                    to={link.href}
                    className="text-secondary-300 hover:text-white transition-colors text-sm"
                  >
                    {link.name}
                  </Link>
                </li>
              ))}
            </ul>
          </div>

          {/* Support Links */}
          <div>
            <h3 className="text-lg font-semibold mb-4">Yordam</h3>
            <ul className="space-y-2">
              {footerLinks.support.map((link) => (
                <li key={link.name}>
                  <Link
                    to={link.href}
                    className="text-secondary-300 hover:text-white transition-colors text-sm"
                  >
                    {link.name}
                  </Link>
                </li>
              ))}
            </ul>
          </div>

          {/* Contact Info */}
          <div>
            <h3 className="text-lg font-semibold mb-4">Bog'lanish</h3>
            <div className="space-y-3">
              <div className="flex items-center space-x-2 text-sm text-secondary-300">
                <Mail className="w-4 h-4" />
                <span>info@edufinder.uz</span>
              </div>
              <div className="flex items-center space-x-2 text-sm text-secondary-300">
                <Phone className="w-4 h-4" />
                <span>+998 90 123 45 67</span>
              </div>
              <div className="flex items-center space-x-2 text-sm text-secondary-300">
                <MapPin className="w-4 h-4" />
                <span>Toshkent, O'zbekiston</span>
              </div>
            </div>
          </div>
        </div>

        {/* Bottom Section */}
        <div className="border-t border-secondary-800 mt-8 pt-8">
          <div className="flex flex-col md:flex-row justify-between items-center space-y-4 md:space-y-0">
            <p className="text-secondary-400 text-sm">
              © {currentYear} EduFinder. Barcha huquqlar himoyalangan.
            </p>
            <div className="flex space-x-6">
              {footerLinks.legal.map((link) => (
                <Link
                  key={link.name}
                  to={link.href}
                  className="text-secondary-400 hover:text-white transition-colors text-sm"
                >
                  {link.name}
                </Link>
              ))}
            </div>
          </div>
        </div>
      </div>
    </footer>
  )
}