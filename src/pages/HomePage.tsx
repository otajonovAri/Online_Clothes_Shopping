import { Link } from 'react-router-dom'
import { ArrowRight, BookOpen, Users, Award, TrendingUp, Star, Play } from 'lucide-react'
import { motion } from 'framer-motion'

export function HomePage() {
  const stats = [
    { label: 'Faol talabalar', value: '10,000+', icon: Users },
    { label: 'Kurslar soni', value: '500+', icon: BookOpen },
    { label: 'Professional o\'qituvchilar', value: '100+', icon: Award },
    { label: 'Tugatilgan kurslar', value: '50,000+', icon: TrendingUp },
  ]

  const featuredCourses = [
    {
      id: '1',
      title: 'React va TypeScript asoslari',
      instructor: 'Alisher Karimov',
      rating: 4.8,
      students: 1250,
      price: 299000,
      image: 'https://images.pexels.com/photos/11035380/pexels-photo-11035380.jpeg?auto=compress&cs=tinysrgb&w=500',
      level: 'Boshlang\'ich',
    },
    {
      id: '2',
      title: 'Python bilan Data Science',
      instructor: 'Malika Tosheva',
      rating: 4.9,
      students: 980,
      price: 399000,
      image: 'https://images.pexels.com/photos/1181671/pexels-photo-1181671.jpeg?auto=compress&cs=tinysrgb&w=500',
      level: 'O\'rta',
    },
    {
      id: '3',
      title: 'UI/UX Design Masterclass',
      instructor: 'Sardor Rahimov',
      rating: 4.7,
      students: 750,
      price: 349000,
      image: 'https://images.pexels.com/photos/196644/pexels-photo-196644.jpeg?auto=compress&cs=tinysrgb&w=500',
      level: 'Boshlang\'ich',
    },
  ]

  const testimonials = [
    {
      name: 'Aziza Normatova',
      role: 'Frontend Developer',
      content: 'EduFinder orqali React o\'rgandim va hozir professional dasturchi sifatida ishlayman. Juda sifatli ta\'lim!',
      avatar: 'https://images.pexels.com/photos/774909/pexels-photo-774909.jpeg?auto=compress&cs=tinysrgb&w=100',
      rating: 5,
    },
    {
      name: 'Bobur Ismoilov',
      role: 'Data Scientist',
      content: 'Python kurslari juda amaliy va tushunarli. O\'qituvchilar professional va har doim yordam berishga tayyor.',
      avatar: 'https://images.pexels.com/photos/220453/pexels-photo-220453.jpeg?auto=compress&cs=tinysrgb&w=100',
      rating: 5,
    },
    {
      name: 'Nilufar Karimova',
      role: 'UX Designer',
      content: 'Design kurslari orqali o\'z kasbimni topdim. Hozir yirik kompaniyada UX Designer sifatida ishlayman.',
      avatar: 'https://images.pexels.com/photos/415829/pexels-photo-415829.jpeg?auto=compress&cs=tinysrgb&w=100',
      rating: 5,
    },
  ]

  return (
    <div className="min-h-screen">
      {/* Hero Section */}
      <section className="relative bg-gradient-to-br from-primary-600 via-primary-700 to-primary-800 text-white overflow-hidden">
        <div className="absolute inset-0 bg-black/10"></div>
        <div className="relative max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-20 lg:py-32">
          <div className="grid grid-cols-1 lg:grid-cols-2 gap-12 items-center">
            <motion.div
              initial={{ opacity: 0, y: 20 }}
              animate={{ opacity: 1, y: 0 }}
              transition={{ duration: 0.6 }}
              className="space-y-8"
            >
              <h1 className="text-4xl lg:text-6xl font-bold leading-tight">
                Kelajagingizni
                <span className="block text-yellow-300">o'zgartiring</span>
              </h1>
              <p className="text-xl text-blue-100 leading-relaxed">
                EduFinder bilan professional ko'nikmalarni o'rganing. 
                Eng yaxshi o'qituvchilar va zamonaviy kurslar bilan 
                muvaffaqiyatga erishing.
              </p>
              <div className="flex flex-col sm:flex-row gap-4">
                <Link
                  to="/courses"
                  className="inline-flex items-center justify-center px-8 py-4 bg-white text-primary-600 font-semibold rounded-lg hover:bg-gray-50 transition-colors group"
                >
                  Kurslarni ko'rish
                  <ArrowRight className="ml-2 w-5 h-5 group-hover:translate-x-1 transition-transform" />
                </Link>
                <button className="inline-flex items-center justify-center px-8 py-4 border-2 border-white text-white font-semibold rounded-lg hover:bg-white hover:text-primary-600 transition-colors group">
                  <Play className="mr-2 w-5 h-5" />
                  Demo ko'rish
                </button>
              </div>
            </motion.div>
            
            <motion.div
              initial={{ opacity: 0, scale: 0.8 }}
              animate={{ opacity: 1, scale: 1 }}
              transition={{ duration: 0.6, delay: 0.2 }}
              className="relative"
            >
              <div className="relative z-10">
                <img
                  src="https://images.pexels.com/photos/3184360/pexels-photo-3184360.jpeg?auto=compress&cs=tinysrgb&w=800"
                  alt="Online Learning"
                  className="rounded-2xl shadow-2xl"
                />
              </div>
              <div className="absolute -top-4 -right-4 w-72 h-72 bg-yellow-300 rounded-full opacity-20 blur-3xl"></div>
              <div className="absolute -bottom-4 -left-4 w-72 h-72 bg-blue-300 rounded-full opacity-20 blur-3xl"></div>
            </motion.div>
          </div>
        </div>
      </section>

      {/* Stats Section */}
      <section className="py-16 bg-white">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div className="grid grid-cols-2 lg:grid-cols-4 gap-8">
            {stats.map((stat, index) => (
              <motion.div
                key={stat.label}
                initial={{ opacity: 0, y: 20 }}
                animate={{ opacity: 1, y: 0 }}
                transition={{ duration: 0.6, delay: index * 0.1 }}
                className="text-center"
              >
                <div className="inline-flex items-center justify-center w-16 h-16 bg-primary-100 rounded-full mb-4">
                  <stat.icon className="w-8 h-8 text-primary-600" />
                </div>
                <div className="text-3xl font-bold text-secondary-900 mb-2">
                  {stat.value}
                </div>
                <div className="text-secondary-600">
                  {stat.label}
                </div>
              </motion.div>
            ))}
          </div>
        </div>
      </section>

      {/* Featured Courses */}
      <section className="py-20 bg-secondary-50">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div className="text-center mb-16">
            <h2 className="text-3xl lg:text-4xl font-bold text-secondary-900 mb-4">
              Mashhur kurslar
            </h2>
            <p className="text-xl text-secondary-600 max-w-2xl mx-auto">
              Eng ko'p tanlanayotgan va yuqori baholangan kurslarimiz bilan tanishing
            </p>
          </div>

          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
            {featuredCourses.map((course, index) => (
              <motion.div
                key={course.id}
                initial={{ opacity: 0, y: 20 }}
                animate={{ opacity: 1, y: 0 }}
                transition={{ duration: 0.6, delay: index * 0.1 }}
                className="card-hover p-0 overflow-hidden group"
              >
                <div className="relative">
                  <img
                    src={course.image}
                    alt={course.title}
                    className="w-full h-48 object-cover group-hover:scale-105 transition-transform duration-300"
                  />
                  <div className="absolute top-4 left-4">
                    <span className="px-3 py-1 bg-primary-600 text-white text-xs font-medium rounded-full">
                      {course.level}
                    </span>
                  </div>
                </div>
                
                <div className="p-6">
                  <h3 className="text-xl font-semibold text-secondary-900 mb-2 group-hover:text-primary-600 transition-colors">
                    {course.title}
                  </h3>
                  <p className="text-secondary-600 mb-4">
                    {course.instructor}
                  </p>
                  
                  <div className="flex items-center justify-between mb-4">
                    <div className="flex items-center space-x-1">
                      <Star className="w-4 h-4 text-yellow-400 fill-current" />
                      <span className="text-sm font-medium text-secondary-700">
                        {course.rating}
                      </span>
                      <span className="text-sm text-secondary-500">
                        ({course.students} talaba)
                      </span>
                    </div>
                  </div>
                  
                  <div className="flex items-center justify-between">
                    <div className="text-2xl font-bold text-primary-600">
                      {course.price.toLocaleString()} so'm
                    </div>
                    <Link
                      to={`/courses/${course.id}`}
                      className="btn-primary text-sm"
                    >
                      Batafsil
                    </Link>
                  </div>
                </div>
              </motion.div>
            ))}
          </div>

          <div className="text-center mt-12">
            <Link
              to="/courses"
              className="btn-primary inline-flex items-center"
            >
              Barcha kurslarni ko'rish
              <ArrowRight className="ml-2 w-4 h-4" />
            </Link>
          </div>
        </div>
      </section>

      {/* Testimonials */}
      <section className="py-20 bg-white">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div className="text-center mb-16">
            <h2 className="text-3xl lg:text-4xl font-bold text-secondary-900 mb-4">
              Talabalarimiz fikri
            </h2>
            <p className="text-xl text-secondary-600 max-w-2xl mx-auto">
              Bizning platformamizda o'qigan talabalarning muvaffaqiyat hikoyalari
            </p>
          </div>

          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
            {testimonials.map((testimonial, index) => (
              <motion.div
                key={testimonial.name}
                initial={{ opacity: 0, y: 20 }}
                animate={{ opacity: 1, y: 0 }}
                transition={{ duration: 0.6, delay: index * 0.1 }}
                className="card p-6"
              >
                <div className="flex items-center mb-4">
                  {[...Array(testimonial.rating)].map((_, i) => (
                    <Star key={i} className="w-4 h-4 text-yellow-400 fill-current" />
                  ))}
                </div>
                
                <p className="text-secondary-700 mb-6 leading-relaxed">
                  "{testimonial.content}"
                </p>
                
                <div className="flex items-center">
                  <img
                    src={testimonial.avatar}
                    alt={testimonial.name}
                    className="w-12 h-12 rounded-full object-cover mr-4"
                  />
                  <div>
                    <div className="font-semibold text-secondary-900">
                      {testimonial.name}
                    </div>
                    <div className="text-sm text-secondary-600">
                      {testimonial.role}
                    </div>
                  </div>
                </div>
              </motion.div>
            ))}
          </div>
        </div>
      </section>

      {/* CTA Section */}
      <section className="py-20 bg-primary-600 text-white">
        <div className="max-w-4xl mx-auto px-4 sm:px-6 lg:px-8 text-center">
          <motion.div
            initial={{ opacity: 0, y: 20 }}
            animate={{ opacity: 1, y: 0 }}
            transition={{ duration: 0.6 }}
            className="space-y-8"
          >
            <h2 className="text-3xl lg:text-4xl font-bold">
              Bugun o'qishni boshlang!
            </h2>
            <p className="text-xl text-blue-100 leading-relaxed">
              Minglab talabalar bizning platformamizda o'z maqsadlariga erishmoqda. 
              Siz ham ularga qo'shiling va professional karyerangizni boshlang.
            </p>
            <div className="flex flex-col sm:flex-row gap-4 justify-center">
              <Link
                to="/register"
                className="btn bg-white text-primary-600 hover:bg-gray-50 px-8 py-4 text-lg font-semibold"
              >
                Bepul ro'yxatdan o'tish
              </Link>
              <Link
                to="/courses"
                className="btn border-2 border-white text-white hover:bg-white hover:text-primary-600 px-8 py-4 text-lg font-semibold"
              >
                Kurslarni ko'rish
              </Link>
            </div>
          </motion.div>
        </div>
      </section>
    </div>
  )
}