import React from 'react';
import { View, Text, Button, StyleSheet } from 'react-native';
import { NativeStackNavigationProp } from '@react-navigation/native-stack';
import { useNavigation } from '@react-navigation/native';

// Define the navigation stack parameter types
type RootStackParamList = {
  Login: undefined;
  Home: undefined;
};

// Type for navigation prop specific to Home screen
type HomeScreenNavigationProp = NativeStackNavigationProp<RootStackParamList, 'Home'>;

export default function HomeScreen() {
  // Get navigation object for screen transitions
  const navigation = useNavigation<HomeScreenNavigationProp>();

  // Handles user logout and navigates to Login screen
  const handleLogout = () => {
    navigation.reset({
      index: 0,
      routes: [{ name: 'Login' }],
    });
  };

  return (
    <View style={styles.container}>
      {/* Welcome message */}
      <Text style={styles.title}>Welcome to Home!</Text>
      {/* Logout button */}
      <Button title="Logout" onPress={handleLogout} />
    </View>
  );
}

// Styles for the home screen components
const styles = StyleSheet.create({
  container: { flex: 1, justifyContent: 'center', padding: 20 },
  title: { fontSize: 24, marginBottom: 20, textAlign: 'center' },
});
